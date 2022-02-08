import { Observable } from 'rxjs';
import { URL_ROOT } from '../constants/core-constants';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Marketer } from 'src/app/shared/models/marketer';

@Injectable({
  providedIn: 'root',
})
export class MarketersService {
  private readonly _apiRoot = `${URL_ROOT}/api/marketers`;

  constructor(private readonly _httpClient: HttpClient) {}

  public getMarketer(id: number): Observable<Marketer> {
    return this._httpClient.get<Marketer>(`${this._apiRoot}/${id}`);
  }

  public getMarketers(): Observable<Array<Marketer>> {
    return this._httpClient.get<Marketer[]>(this._apiRoot);
  }
}
