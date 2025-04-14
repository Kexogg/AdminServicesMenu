import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react";

const BASE_URL = import.meta.env.VITE_API_URL ?? "";

export const emptySplitApi = createApi({
    baseQuery: fetchBaseQuery({baseUrl: BASE_URL, credentials: "include"}),
    endpoints: () => ({}),
});
