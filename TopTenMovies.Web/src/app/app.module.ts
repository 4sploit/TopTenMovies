import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AddMovieTriggerComponent } from './components/addMovieTrigger/addMovieTrigger.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AddMovieFormModalComponent } from './components/addMovieFormModal/addMovieFormModal.component';
import { FormFocusOnErrorDirective } from './directives/formFocusOnError/formFocusOnError.directive';
import { MovieListComponent } from './components/movieList/movieList.component';
import { MovieComponent } from './components/movie/movie.component';
import { MovieFilterComponent } from './components/movieFilter/movieFilter.component';
import { FilterByGenrePipe } from './pipes/filterByGenre.pipe';

@NgModule({
  declarations: [
    AppComponent,
    AddMovieTriggerComponent,
    AddMovieFormModalComponent,
    FormFocusOnErrorDirective,
    MovieListComponent,
    MovieComponent,
    MovieFilterComponent,
    FilterByGenrePipe
  ],
  imports: [
    NgbModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    AddMovieFormModalComponent
  ]
})
export class AppModule { }
