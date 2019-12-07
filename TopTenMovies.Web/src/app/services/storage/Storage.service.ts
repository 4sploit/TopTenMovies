import { Injectable } from '@angular/core';
import { Subject, Observable, BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class Storage<T> {
  protected stateHandler: BehaviorSubject<T>;

  constructor(defaultValue: T) {
    this.stateHandler = new BehaviorSubject<T>(defaultValue);
  }

  get() {
      return this.stateHandler.asObservable();
  }

  set(state: T) {
      this.stateHandler.next(state);
  }

  getValue() {
    return this.stateHandler.getValue();
  }
}
