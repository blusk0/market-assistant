import { Book } from '../../shared/models/book';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { URL_ROOT } from './../constants/core-constants';
import { Injectable } from '@angular/core';
import { ChartBreakdown } from 'src/app/shared/models/chart-breakdown';
import { Marketer } from 'src/app/shared/models/marketer';


@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  private readonly _apiRoot = `${URL_ROOT}/api/dashboard`;

  constructor(private readonly _httpClient: HttpClient) { }

  public getChartBreakdown(): Observable<ChartBreakdown> {
    return this._httpClient.get<ChartBreakdown>(`${this._apiRoot}/chart`);
  }

  public getMarketersWithoutAssignments(): Observable<Array<Marketer>> {
    return this._httpClient.get<Marketer[]>(`${this._apiRoot}/marketers-without-assignments`);
  }

  public getNearlyPublishedBooks(): Observable<Array<Book>> {
    return this._httpClient.get<Book[]>(`${this._apiRoot}/upcoming-books`);
  }
}
