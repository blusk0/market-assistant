import { Author } from 'src/app/shared/models/author';
import { Subject, takeUntil } from 'rxjs';
import { AuthorsService } from './../../core/services/authors.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-authors',
  templateUrl: './authors.component.html',
  styleUrls: ['./authors.component.scss'],
})
export class AuthorsComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();

  public dataSource: MatTableDataSource<Author> = new MatTableDataSource();
  public readonly displayedColumns: string[] = [
    'firstName',
    'lastName',
    'bookCount',
  ];

  constructor(private readonly _authorsService: AuthorsService) {}

  public ngOnInit(): void {
    this._authorsService
      .getAuthors()
      .pipe(takeUntil(this._destroy$))
      .subscribe((authors) => {
        this.dataSource.data = authors;
      });
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
