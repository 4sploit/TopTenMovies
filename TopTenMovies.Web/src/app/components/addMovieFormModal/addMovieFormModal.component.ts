import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MovieApiService } from '../../services/api/movieApi.service';
import { Genre } from '../../models/genre';
import { Movie } from '../../models/movie';
import { GenreStorage } from '../../services/storage/genreStorage.service';
import { MovieStorage } from '../../services/storage/movieStorage.service';

@Component({
  selector: 'addMovieFormModal',
  templateUrl: './addMovieFormModal.component.html',
  styleUrls: ['./addMovieFormModal.component.css']
})

export class AddMovieFormModalComponent implements OnInit {
  @Input() id: number;
  newMovieForm: FormGroup;
  currentRate: number;
  submitted: boolean;
  movieExists: boolean;
  sucessAdded: boolean;
  genres: Genre[];
  movies: Movie[];

  constructor(
   public activeModal: NgbActiveModal,
   private formBuilder: FormBuilder,
   private movieApiService: MovieApiService,
   private genreStorage: GenreStorage,
   private movieStorage: MovieStorage
  ) {
    this.currentRate = 0;
    this.genres = [];
    this.movies = [];
    this.movieExists = this.sucessAdded = false;

    this.createForm();
  }

  get mf() { return this.newMovieForm.controls; }

  private createForm() {
    this.newMovieForm = this.formBuilder.group({
      Title: ['', Validators.required],
      Genre: ['', Validators.required],
      Rating: 0
    });
  }

  private isExistingMovie(movie: Movie): boolean {
    const result = this.movies.filter(curMovie => {
      return (
        // tslint:disable-next-line:triple-equals
        (curMovie.Title.toLowerCase() == movie.Title.toLowerCase()) &&
        // tslint:disable-next-line:triple-equals
        (curMovie.Genre == movie.Genre)
      );
    });

    return result.length > 0;
  }

  addMovie(movie: Movie) {
    this.submitted = true;
    this.sucessAdded = false;

    if (this.newMovieForm.invalid) {
      return;
    }

    if (this.isExistingMovie(movie))  {
      this.movieExists = true;
      return;
    }

    this.movieExists = false;

    this.movieApiService
      .addMovie(movie)
      .subscribe(resp => {
        if (resp != null) {
          this.sucessAdded = true;

          this.movies.splice(this.movies.length - 1);
          this.movies.push(resp);
          this.movies = this.movies.sort((a, b) => b.Rating - a.Rating);

          this.movieStorage.set(this.movies);

          this.submitted = false;
          this.newMovieForm.reset();
        }
      });
  }

  ngOnInit(): void {
    const genresStorage = this.genreStorage.get();
    const moviesStorage = this.movieStorage.get();

    genresStorage
        .subscribe(genres => {
          this.genres = genres;
        });

    moviesStorage
        .subscribe(movies => {
          this.movies = movies;
        });
  }
}
