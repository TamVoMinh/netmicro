import { Component, OnInit, Input, Output, EventEmitter, OnChanges, SimpleChanges } from '@angular/core';
import { IClient } from '@app/shared/common/_model/client.interface';
import { IHttpResponse } from '@app/shared/common';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';

@Component({
  selector: 'app-clients',
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnChanges {
  @Input() clients: IHttpResponse<IClient[]>;
  @Output() getClients = new EventEmitter();
  defaultColumns = ['ClientId', 'ClientName', 'AllowedGrantTypes', 'RequiredPKCE', 'CreatedDate'];
  allColumns = [...this.defaultColumns];
  dataSource: NbTreeGridDataSource<IClient>;
  sortColumn: string;
  sortDirection: NbSortDirection = NbSortDirection.NONE;
  searchString = '';
  pagingOptions = {
    pageIndex: 1,
    pageSize: 10
  };

  maxSize = 5;
  totalItems = 0;
  constructor(
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<IClient>
  ) { }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes['clients'] !== undefined) {
      var change = changes['clients'];
      if (!change.firstChange) {
        this.loadData(changes['clients'].currentValue);
      }
    }
  }

  loadData(dataSource) {
    this.totalItems = dataSource.total;
    const data: TreeNode<any>[] = dataSource.data.map((item) => {
      return {
        data: {
          ClientId: item.clientId,
          ClientName: item.clientName,
          AllowedGrantTypes: item.allowedGrantTypes.toString(),
          RequiredPKCE: item.requirePkce,
          CreatedDate: item.createdDate
        },
        children: null,
        expanded: false
      }
    })
    this.dataSource = this.dataSourceBuilder.create(data);
  }


  updateSort(sortRequest: NbSortRequest): void {
    this.sortColumn = sortRequest.column;
    this.sortDirection = sortRequest.direction;
  }

  getSortDirection(column: string): NbSortDirection {
    if (this.sortColumn === column) {
      return this.sortDirection;
    }
    return NbSortDirection.NONE;
  }

  onSearch(searchString) {
    this.searchString = searchString;
    this.getClientList();
  }

  pageChanged(event: any) {
    this.pagingOptions.pageIndex = event.page;
    this.pagingOptions.pageSize = event.itemsPerPage;
    this.getClientList();
  }

  getClientList() {
    this.getClients.emit({ ...this.pagingOptions, clientName: this.searchString })
  }

}

interface TreeNode<T> {
  data: T;
  children?: TreeNode<T>[];
  expanded?: boolean;
}
