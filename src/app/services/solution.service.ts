import { HttpClient } from "@angular/common/http";
import {Injectable} from '@angular/core';
import { SolutionModel } from "src/models/solution.model";

@Injectable()
export class SolutionService{

    constructor(private httpClient:HttpClient){

    }
    
    provideSolution(solution:SolutionModel){
        return this.httpClient.post("http://localhost:5015/api/Solution/Provide Solution",solution);
    }
}