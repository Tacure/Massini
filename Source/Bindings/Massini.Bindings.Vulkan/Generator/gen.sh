#!/usr/bin/env bash

set -euo pipefail

CLANG_RESOURCE_DIR="$(clang -print-resource-dir)"

dotnet ClangSharpPInvokeGenerator \
    @generate.rsp \
    --resource-directory "$CLANG_RESOURCE_DIR"