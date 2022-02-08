import { URL_ROOT } from '../constants/core-constants';
import { Book } from '../../shared/models/book';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({ providedIn: 'root' })
export class BooksService {
  private readonly apiRoot = `${URL_ROOT}/api/books`;

  constructor(private readonly _httpClient: HttpClient) {}

  public getBooks(): Observable<Array<Book>> {
    return this._httpClient.get<Array<Book>>(this.apiRoot);
  }

  public getBook(id: number): Observable<Book> {
    return this._httpClient.get<Book>(`${this.apiRoot}/${id}`);
  }
}
