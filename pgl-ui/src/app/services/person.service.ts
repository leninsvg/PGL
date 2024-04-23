import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private readonly url: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.url = environment.apiUrl + '/api/person';
  }

  public getClients(filter: { page: number; pageSize: number; }): Observable<any> {
    const url = this.url + '/clients';
    return this.httpClient.get(url, {params: filter})
  }

  public getClientsSP(filter: { page: number; pageSize: number; }): Observable<any> {
    const url = this.url + '/clients-sp';
    return this.httpClient.get(url, {params: filter})
  }
}
