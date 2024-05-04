import { BodyType } from "../enums/BodyType";
import { Color } from "../enums/Color";
import { Status } from "../enums/Status";
import { PhotoModel } from "./photoModel";

export class CarModel{
    id: string = '';
    identityCode: string = '';
    model: string = '';
    yearOfEdition: number = 0;
    bodyType: BodyType = 0;
    color: Color = 0;
    engine: string = "";
    fuelConsumption: number = 0.0;
    price: number = 0.0;
    status: Status = 0;
    porscheCenterId: number = 0;
    photos: PhotoModel[] | null = [];
}