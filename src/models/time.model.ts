export class TimeModel{
    constructor(public id:number=0,
    public userId:number=0,
    public logInTime:Date = new Date(),
    public logOutTime:Date = new Date()){

    }
}
