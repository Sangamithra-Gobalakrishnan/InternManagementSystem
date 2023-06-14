import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable()
export class InternService{

    constructor(private http:HttpClient) {
        
    }

    getInterns(){
      var header=new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+localStorage.getItem("token")?.toString()
      });
       return this.http.get("http://localhost:5071/api/Filter/Get All Users",{headers:header});
    }

    changeStatus(id:number):Observable<any>{
        var header = new HttpHeaders({
         'Content-Type':'application/json',
         'Authorization':'Bearer'+localStorage.getItem("token")?.toString()
        });
        return this.http.put(`http://localhost:5071/api/Login/Update Status?UserID=${id}`,{headers:header});
        
     }
}
