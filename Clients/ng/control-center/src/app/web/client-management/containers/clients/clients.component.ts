import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IClient } from '@app/shared/common/_model/client.interface';
import { Store, select } from '@ngrx/store';
import { selectClientList } from '@app/core/store/selectors/client.selector';
import { GetClients } from '@app/core/store/actions/client.action';
import { IHttpResponse } from '@app/shared/common/_model/http-response.interface';

@Component({
  templateUrl: './clients.component.html',
  styleUrls: ['./clients.component.scss']
})
export class ClientsComponent implements OnInit {
  clients$: Observable<IHttpResponse<IClient[]>> = this.store.pipe(select(selectClientList));

  constructor(
    private store: Store
  ) { }

  ngOnInit() {
    this.store.dispatch(new GetClients({ clientName: '', limit: 50, offset: 0 }))
  }

  getClients(event: any) {
    this.store.dispatch(new GetClients({ limit: event.pageSize, offset: event.pageIndex, clientName: event.clientName }));
  }
}
