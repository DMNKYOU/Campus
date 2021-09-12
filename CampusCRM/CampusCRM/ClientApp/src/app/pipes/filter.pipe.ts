import { Pipe, PipeTransform } from '@angular/core';
import { Student } from '../student/student.component';

@Pipe({
  name: 'filter'
})
export class FilterPipe implements PipeTransform {

    transform(val: Student[], input: any): any {
        if (input) {
          return val.filter(val => val.name.toLowerCase().indexOf(input.toLowerCase()) >= 0);
        }
        else {
          return val;
        }
    }
}