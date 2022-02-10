import { BooksService } from './../../../core/services/books.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { Book } from 'src/app/shared/models/book';
import { ActivatedRoute } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MarketerAssignment } from 'src/app/shared/models/marketerAssignment';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.scss'],
})
export class BookComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();
  private bookId: string;
  public book$ = new Subject<Book>();

  noMarketerAssignment = ""

  public MarketerAssignmentSource: MatTableDataSource<MarketerAssignment> = new MatTableDataSource();
  marketerAssignmentDisplayedColumns = ['name', 'date'];

  public MarketingMaterialSource: MatTableDataSource<any> = new MatTableDataSource();
  marketingMaterialDisplayedColumns = ['type', 'startdate', 'enddate'];

  public EventSource: MatTableDataSource<any> = new MatTableDataSource();
  eventDisplayedColumns = ['eventtype', 'eventdate'];

  

  constructor(
    private readonly route: ActivatedRoute,
    private readonly _booksService: BooksService
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    this.bookId = id ? id : '0';
  }

  ngOnInit(): void {
    this._booksService
      .getBook(+this.bookId)
      .pipe(takeUntil(this._destroy$))
      .subscribe((book) => {
        this.book$.next(book)
        this.MarketerAssignmentSource.data = book.marketerAssignments
        this.MarketingMaterialSource.data = book.marketMaterials
        this.EventSource.data = book.events
      });
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
