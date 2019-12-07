export class Movie {
  public Cover: string;
  public Title: string;
  public Genre: number;
  public Rating: number;
  // tslint:disable-next-line:variable-name
  public _Genre: string;

  // tslint:disable-next-line:variable-name
  constructor(cover: string, title: string, genre: number, rating: number, _genre: string) {
    this.Cover = cover;
    this.Title = title;
    this.Genre = genre;
    this.Rating = rating;
    this._Genre = _genre;
  }
}
