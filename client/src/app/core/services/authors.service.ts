import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { URL_ROOT } from './../constants/core-constants';
import { Injectable } from '@angular/core';
import { Author } from 'src/app/shared/models/author';

@Injectable({ providedIn: 'root' })
export class AuthorsService {
  private readonly _apiRoot = `${URL_ROOT}/api/authors`;

  constructor(private readonly _httpClient: HttpClient) {}

  public getAuthor(id: number): Observable<Author> {
    return this._httpClient.get<Author>(`${this._apiRoot}/${id}`);
  }

  public getAuthors(): Observable<Array<Author>> {
    return this._httpClient.get<Author[]>(this._apiRoot);
  }
}
