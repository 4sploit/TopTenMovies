import { Component, OnInit } from '@angular/core';
import { MovieApiService } from './services/api/movieApi.service';
import { GenreApiService } from './services/api/genreApi.service';
import { Movie } from './models/movie';
import { Genre } from './models/genre';
import { MovieStorage } from './services/storage/movieStorage.service';
import { GenreStorage } from './services/storage/genreStorage.service';
import { FilterByGenrePipe } from './pipes/filterByGenre.pipe';

@Component({
  selector: 'top-ten-movies-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'TopTenMovies';
  filterVal: number;

  constructor(
    private movieApiService: MovieApiService,
    private genreApiService: GenreApiService,
    private movieStorage: MovieStorage,
    private genreStorage: GenreStorage) {
      this.filterVal = 0;
  }

  updateFilterVal(newFilterVal: number) {
    this.filterVal = newFilterVal;
  }

  ngOnInit() {
    const genres: Genre[] = [];
    const movies: Movie[] = [];

    this.movieApiService
        .fetchMovies()
        .subscribe(resp => {
          for (const data of resp.body) {
            movies.push(data);
          }

          this.movieStorage.set(movies.sort((a, b) => b.Rating - a.Rating ));
        });

    this.genreApiService
        .fetchGenres()
        .subscribe(resp => {
          for (const data of resp.body) {
            genres.push(data);
          }

          this.genreStorage.set(genres);
        });
  }
}
