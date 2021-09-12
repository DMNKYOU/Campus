import { HttpClient } from "@angular/common/http";
import { Component, Inject } from "@angular/core";
import { StudentService } from "./student.service";

@Component({
    selector: 'app-student',
    templateUrl: './student.component.html',
    styleUrls: ['./student.compomemt.css'],
    providers: [StudentService]
  })
  export class StudentComponent {
    public students: Student[];
    studentName = '';

    constructor(private studentService : StudentService){}

    ngOnInit(): void {
      this.studentService.getStudents().subscribe(result => {
        this.students = result;
      },
      error => {console.error(error);});
    }

    sort(prop: string, isUp : boolean){
      this.students = this.students.sort(function (a, b) {
        if(isUp){
          return (a[prop] > b[prop]) ? 1 : ((a[prop] < b[prop]) ? -1 : 0);
        }
        else{
          return (b[prop] > a[prop]) ? 1 : ((b[prop] < a[prop]) ? -1 : 0);
        }
      });
    }
  }

  export interface Student {
    id: number;
    name: string;
    surname: string;
    age: number;
  }
