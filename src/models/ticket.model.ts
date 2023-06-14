export class TicketModel{
    constructor(public ticketID:number=0,
    public issuerID:number=0,
    public issueTitle:string="",
    public issueDescription:string="",
    public priority:string="",
    public category:string=""){    
    }
}