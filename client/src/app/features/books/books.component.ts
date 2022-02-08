import { Book } from '../../shared/models/book';
import { BooksService } from '../../core/services/books.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss'],
})
export class BooksComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();

  public dataSource: MatTableDataSource<Book> = new MatTableDataSource();
  public readonly displayedColumns: string[] = [
    'title',
    'isbn',
    'publishDate',
    'authorFirstName',
    'authorLastName',
    'format',
  ];

  constructor(private readonly _booksService: BooksService) {}

  public ngOnInit(): void {
    this._booksService
      .getBooks()
      .pipe(takeUntil(this._destroy$))
      .subscribe((books) => (this.dataSource.data = books));
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
