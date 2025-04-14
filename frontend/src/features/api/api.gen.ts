import { emptySplitApi as api } from "./emptyApi";
export const addTagTypes = ["Preset", "Service"] as const;
const injectedRtkApi = api
  .enhanceEndpoints({
    addTagTypes,
  })
  .injectEndpoints({
    endpoints: (build) => ({
      getCurrentPreset: build.query<
        GetCurrentPresetApiResponse,
        GetCurrentPresetApiArg
      >({
        query: (queryArg) => ({ url: `/api/preset/${queryArg.id}` }),
        providesTags: ["Preset"],
      }),
      deleteApiPresetById: build.mutation<
        DeleteApiPresetByIdApiResponse,
        DeleteApiPresetByIdApiArg
      >({
        query: (queryArg) => ({
          url: `/api/preset/${queryArg.pathId}`,
          method: "DELETE",
          params: {
            id: queryArg.queryId,
          },
        }),
        invalidatesTags: ["Preset"],
      }),
      putApiPresetById: build.mutation<
        PutApiPresetByIdApiResponse,
        PutApiPresetByIdApiArg
      >({
        query: (queryArg) => ({
          url: `/api/preset/${queryArg.id}`,
          method: "PUT",
          body: queryArg.presetUpdateDto,
        }),
        invalidatesTags: ["Preset"],
      }),
      getPresets: build.query<GetPresetsApiResponse, GetPresetsApiArg>({
        query: (queryArg) => ({
          url: `/api/preset`,
          params: {
            pageNumber: queryArg.pageNumber,
            pageSize: queryArg.pageSize,
          },
        }),
        providesTags: ["Preset"],
      }),
      postApiPreset: build.mutation<
        PostApiPresetApiResponse,
        PostApiPresetApiArg
      >({
        query: (queryArg) => ({
          url: `/api/preset`,
          method: "POST",
          body: queryArg.presetCreateDto,
        }),
        invalidatesTags: ["Preset"],
      }),
      getApiService: build.query<GetApiServiceApiResponse, GetApiServiceApiArg>(
        {
          query: (queryArg) => ({
            url: `/api/service`,
            params: {
              pageNumber: queryArg.pageNumber,
              pageSize: queryArg.pageSize,
            },
          }),
          providesTags: ["Service"],
        },
      ),
      postApiService: build.mutation<
        PostApiServiceApiResponse,
        PostApiServiceApiArg
      >({
        query: (queryArg) => ({
          url: `/api/service`,
          method: "POST",
          body: queryArg.serviceCreateDto,
        }),
        invalidatesTags: ["Service"],
      }),
      getApiServiceById: build.query<
        GetApiServiceByIdApiResponse,
        GetApiServiceByIdApiArg
      >({
        query: (queryArg) => ({ url: `/api/service/${queryArg.id}` }),
        providesTags: ["Service"],
      }),
      deleteApiServiceById: build.mutation<
        DeleteApiServiceByIdApiResponse,
        DeleteApiServiceByIdApiArg
      >({
        query: (queryArg) => ({
          url: `/api/service/${queryArg.id}`,
          method: "DELETE",
        }),
        invalidatesTags: ["Service"],
      }),
      putApiServiceById: build.mutation<
        PutApiServiceByIdApiResponse,
        PutApiServiceByIdApiArg
      >({
        query: (queryArg) => ({
          url: `/api/service/${queryArg.id}`,
          method: "PUT",
          body: queryArg.serviceUpdateDto,
        }),
        invalidatesTags: ["Service"],
      }),
    }),
    overrideExisting: false,
  });
export { injectedRtkApi as api };
export type GetCurrentPresetApiResponse = /** status 200 OK */ PresetReponseDto;
export type GetCurrentPresetApiArg = {
  id: string;
};
export type DeleteApiPresetByIdApiResponse =
  /** status 200 OK */ PresetReponseDto;
export type DeleteApiPresetByIdApiArg = {
  queryId?: string;
  pathId: string;
};
export type PutApiPresetByIdApiResponse = /** status 200 OK */ PresetReponseDto;
export type PutApiPresetByIdApiArg = {
  id: string;
  presetUpdateDto: PresetUpdateDto;
};
export type GetPresetsApiResponse = /** status 200 OK */ PresetReponseDto[];
export type GetPresetsApiArg = {
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiPresetApiResponse = /** status 200 OK */ PresetReponseDto;
export type PostApiPresetApiArg = {
  presetCreateDto: PresetCreateDto;
};
export type GetApiServiceApiResponse = unknown;
export type GetApiServiceApiArg = {
  pageNumber?: number;
  pageSize?: number;
};
export type PostApiServiceApiResponse = unknown;
export type PostApiServiceApiArg = {
  serviceCreateDto: ServiceCreateDto;
};
export type GetApiServiceByIdApiResponse = unknown;
export type GetApiServiceByIdApiArg = {
  id: string;
};
export type DeleteApiServiceByIdApiResponse = unknown;
export type DeleteApiServiceByIdApiArg = {
  id: string;
};
export type PutApiServiceByIdApiResponse = unknown;
export type PutApiServiceByIdApiArg = {
  id: string;
  serviceUpdateDto: ServiceUpdateDto;
};
export type PresetReponseDto = {
  id?: string;
};
export type Favorite = {
  serviceKey?: string;
};
export type PresetUpdateDto = {
  favorites?: Favorite[];
};
export type PresetCreateDto = {
  favorites?: Favorite[];
};
export type ServiceCreateDto = {
  key?: string;
  title?: string;
  subtitle?: string;
  link?: string;
  icon?: string;
  noReferrer?: boolean | null;
};
export type ServiceUpdateDto = {
  key?: string;
  title?: string;
  subtitle?: string;
  link?: string;
  icon?: string;
  noReferrer?: boolean | null;
};
export const {
  useGetCurrentPresetQuery,
  useDeleteApiPresetByIdMutation,
  usePutApiPresetByIdMutation,
  useGetPresetsQuery,
  usePostApiPresetMutation,
  useGetApiServiceQuery,
  usePostApiServiceMutation,
  useGetApiServiceByIdQuery,
  useDeleteApiServiceByIdMutation,
  usePutApiServiceByIdMutation,
} = injectedRtkApi;
