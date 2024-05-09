import { BodyType } from "../enums/BodyType";
import { Color } from "../enums/Color";

export class SearchByConditionalsModel{
    model: string | null = null;
    bodyType: BodyType[] = [];
    color: Color[] = [];
    minYearOfRelease: number | null = null;
    maxYearOfRelease: number | null = null;
    engine: string[] = [];
    minPrice: number | null = null;
    maxPrice: number | null = null;
    porscheCenter: string[] = [];
}