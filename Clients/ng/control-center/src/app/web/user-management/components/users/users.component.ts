import { Component, OnInit, Input, OnChanges, SimpleChanges, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { IUser, IHttpResponse } from '@app/shared/common/_model';
import { NbSortDirection, NbSortRequest, NbTreeGridDataSource, NbTreeGridDataSourceBuilder } from '@nebular/theme';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnChanges {
  @Input() users: IHttpResponse<IUser[]>;
  @Output() getUsers = new EventEmitter();
  defaultColumns = ['Username', 'Email', 'CreatedDate'];
  allColumns = [...this.defaultColumns];
  dataSource: NbTreeGridDataSource<IUser>;
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
    private dataSourceBuilder: NbTreeGridDataSourceBuilder<IUser>
  ) { }

  ngOnChanges(changes: SimpleChanges): void {
    if (typeof changes['users'] !== undefined) {
      var change = changes['users'];
      if (!change.firstChange) {
        this.loadData(changes['users'].currentValue);
      }
    }
  }

  loadData(dataSource) {
    this.totalItems = dataSource.total;
    const data: TreeNode<any>[] = dataSource.data.map((item) => {
      return {
        data: {
          Username: item.userName,
          Email: item.email,
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
    this.getUserList();
  }

  pageChanged(event: any) {
    this.pagingOptions.pageIndex = event.page;
    this.pagingOptions.pageSize = event.itemsPerPage;
    this.getUserList();
  }

  getUserList() {
    this.getUsers.emit({ ...this.pagingOptions, email: this.searchString })
  }
}

interface TreeNode<T> {
  data: T;
  children?: TreeNode<T>[];
  expanded?: boolean;
}
