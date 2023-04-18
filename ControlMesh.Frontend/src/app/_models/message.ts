import { MessageCustomProperties } from "./messageCustomProperties";
import { MessageSystemProperties } from "./messageSystemProperties";

export interface Message {
    id: number;
    content: string;
    type: string;
    created?: Date;
    messageSystemProperties: MessageSystemProperties,
    messageCustomProperties: MessageCustomProperties
}