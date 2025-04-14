import type {ConfigFile} from "@rtk-query/codegen-openapi";

const config: ConfigFile = {
    schemaFile: "http://localhost:5251/swagger/v1/swagger.json",
    apiFile: "./src/features/api/emptyApi.ts",
    apiImport: "emptySplitApi",
    outputFile: "./src/features/api/api.gen.ts",
    exportName: "api",
    tag: true,
    hooks: true,
};

export default config;
