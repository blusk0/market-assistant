import { Book } from '../../shared/models/book';
import { BooksService } from '../../core/services/books.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params } from '@angular/router';

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

  BookList: Book[] = []
  queryParams: any

  constructor(private readonly _booksService: BooksService, private route: ActivatedRoute) {

    this.route.params
      .subscribe((params: any )=> {
        this.queryParams = params.label;
        if (params.label)
          this.getFilteredBookList(params.label)
      }
    );

  }

  public ngOnInit(): void {
    if (!this.queryParams)
      this.getBookList()
  }

  getBookList() {
    this._booksService
      .getBooks()
      .pipe(takeUntil(this._destroy$))
      .subscribe((books) => {
        this.BookList = books
        this.dataSource.data = this.BookList
      });
  }

  getFilteredBookList(label: string) {
    this._booksService
      .getBooks()
      .pipe(takeUntil(this._destroy$))
      .subscribe((books) => {
        this.BookList = books

        if (label == 'No Materials') {
          let _bookList = this.BookList.filter((book) => {
            return book.marketMaterials?.length == 0
          })

          this.dataSource.data = _bookList
        }

        if (label == 'No Events') {
          let _bookList = this.BookList.filter((book) => {
            return book.events?.length == 0
          })

          this.dataSource.data = _bookList
        }

        if (label == 'Fully Covered') {
          let _bookList = this.BookList.filter((book) => {
            return book.events.length > 0 && 
                   book.marketMaterials.length > 0 && 
                   book.marketerAssignments.length > 0
          })

          this.dataSource.data = _bookList
        }

        if (label == 'No Coverage') {
          let _bookList = this.BookList.filter((book) => {
            return book.events.length == 0 && 
                   book.marketMaterials.length == 0 && 
                   book.marketerAssignments.length == 0
          })

          this.dataSource.data = _bookList
        }

        if (label == 'No Marketer') {
          let _bookList = this.BookList.filter((book) => {
            return book.marketerAssignments.length == 0
          })

          this.dataSource.data = _bookList
        }

        //this.dataSource.data = this.BookList
      });
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
