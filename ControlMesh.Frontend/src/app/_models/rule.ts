export interface RuleValue {
    hasValue: boolean;
    value: Rule;
}

export interface Rule {
    filter: object;
    action: string;
    name: string;
}