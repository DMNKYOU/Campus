import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'students',
  templateUrl: './students.component.html'
})
export class StudentsComponent {
  public students: StudentModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<StudentModel[]>(baseUrl + 'students').subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }
}

interface StudentModel {
  id: number;
  name: string;
  surname: string;
  age: number;
  groupId: number;
  groupName: string;
}
      
