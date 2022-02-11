import { Component, OnInit, OnDestroy  } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { Marketer } from 'src/app/shared/models/marketer';
import { ActivatedRoute } from '@angular/router';
import { MarketersService } from '../../../core/services/marketers.service';

@Component({
  selector: 'app-marketer',
  templateUrl: './marketer.component.html',
  styleUrls: ['./marketer.component.scss']
})
export class MarketerComponent implements OnInit, OnDestroy {

  private readonly _destroy$ = new Subject();
  private marketerId: string;
  public marketer$ = new Subject<Marketer>();
  constructor(
    private readonly route: ActivatedRoute,
    private readonly _marketersService: MarketersService
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    this.marketerId = id ? id : '0';
  }

  ngOnInit(): void {
    this._marketersService
      .getMarketer(+this.marketerId)
      .pipe(takeUntil(this._destroy$))
      .subscribe((marketer) => this.marketer$.next(marketer));
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
