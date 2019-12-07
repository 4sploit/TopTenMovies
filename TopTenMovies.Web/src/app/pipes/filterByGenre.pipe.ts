import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'filterByGenre',
    pure: false
})
export class FilterByGenrePipe implements PipeTransform {
    transform(items: any[], genre: number): any {
        // tslint:disable-next-line:triple-equals
        if (!items || genre == 0) {
            return items;
        }
        // tslint:disable-next-line:triple-equals
        return items.filter(item => item.Genre == genre);
    }
}