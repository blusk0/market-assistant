import { Marketer } from './../../shared/models/marketer';
import { MarketersService } from './../../core/services/marketers.service';
import { Subject, takeUntil } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-marketers',
  templateUrl: './marketers.component.html',
  styleUrls: ['./marketers.component.scss'],
})
export class MarketersComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();

  public dataSource: MatTableDataSource<Marketer> = new MatTableDataSource();
  public readonly displayedColumns: string[] = [
    'firstName',
    'lastName',
    'assignments',
  ];

  constructor(private readonly _marketersService: MarketersService) {}

  ngOnInit(): void {
    this._marketersService
      .getMarketers()
      .pipe(takeUntil(this._destroy$))
      .subscribe((marketers) => {
        this.dataSource.data = marketers;
      });
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
