import { Author } from './../../../shared/models/author';
import { Subject, takeUntil } from 'rxjs';
import { AuthorsService } from './../../../core/services/authors.service';
import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss'],
})
export class AuthorComponent implements OnInit, OnDestroy {
  private readonly _destroy$ = new Subject();
  private authorId: number;
  public author$ = new Subject<Author>();

  constructor(
    private router: Router,
    private readonly route: ActivatedRoute,
    private readonly _authorsService: AuthorsService
  ) {
    const id = this.route.snapshot.paramMap.get('id');
    this.authorId = id ? +id : 0;
  }

  ngOnInit(): void {
    this._authorsService
      .getAuthor(this.authorId)
      .pipe(takeUntil(this._destroy$))
      .subscribe((author) => this.author$.next(author));
  }

  view(element: any) {
    this.router.navigate(
      ['/book/', { id: element.id}]
    );
    console.log(element)
  }

  public ngOnDestroy(): void {
    this._destroy$.next(null);
    this._destroy$.complete();
  }
}
