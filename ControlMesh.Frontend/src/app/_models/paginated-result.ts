export interface PaginatedResult<T> {
    count: number;
    pageIndex: number;
    pageSize: number;
    items: T[];
}