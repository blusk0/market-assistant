import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksComponent } from './books.component';
import { BookComponent } from './book/book.component';

@NgModule({
  declarations: [BooksComponent, BookComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {
        path: ':id',
        component: BookComponent,
      },
      {
        path: '',
        component: BooksComponent,
      },
    ]),
    SharedModule,
  ],
})
export class BooksModule {}
