import { Marketer } from 'src/app/shared/models/marketer';
import { MatTableDataSource } from '@angular/material/table';
import { ChartTitleItem } from './../../shared/models/chart-title-item';
import { DashboardService } from './../../core/services/dashboard.service';
import { Subject, takeUntil } from 'rxjs';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { Book } from 'src/app/shared/models/book';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
})
export class DashboardComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();

  chartView: any = [700, 400];
  chartColorScheme: any = {
    domain: ['#039BE5', '#FF5722', '#FF6F00', '#FDD835', '#5D4037'],
  };

  marketerDisplayedColumns = ['firstName', 'lastName'];
  public readonly marketerDataSource = new MatTableDataSource<Marketer>();

  bookDisplayColumns: string[] = [
    'title',
    'isbn',
    'publishDate',
    'authorFirstName',
    'authorLastName',
    'format',
    'events',
    'materials',
    'marketerAssigned',
  ];
  public readonly bookDataSource = new MatTableDataSource<Book>();

  public data: ChartTitleItem[] = [];

  constructor(private router: Router,private readonly _dashboardService: DashboardService) {}

  ngOnInit(): void {
    this._dashboardService
      .getChartBreakdown()
      .pipe(takeUntil(this._destroy$))
      .subscribe(
        (breakdown) =>
          (this.data = [
            breakdown.fullyCovered,
            breakdown.noCoverage,
            breakdown.noEvents,
            breakdown.noMaterials,
            breakdown.noMarketer,
          ])
      );

    this._dashboardService
      .getMarketersWithoutAssignments()
      .pipe(takeUntil(this._destroy$))
      .subscribe((marketers) => (this.marketerDataSource.data = marketers));

    this._dashboardService
      .getNearlyPublishedBooks()
      .pipe(takeUntil(this._destroy$))
      .subscribe((books) => (this.bookDataSource.data = books));
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }

  onChartSelect(event: any) {
    const selectedBookIds = this.data.find(x => x.name == event.name)?.titleIds.join();
    this.router.navigate([`../books`, { ids: selectedBookIds, skipLocationChange: true }]);
  }
}
