cmake_minimum_required(VERSION 3.15)
project(VmaExporter LANGUAGES CXX C)

if(DEFINED ENV{VULKAN_SDK})
    set(Vulkan_ROOT $ENV{VULKAN_SDK})
endif()

# Find the Vulkan SDK.
find_package(Vulkan REQUIRED)

# Register header and source files.
add_library(VmaExporter SHARED 
    "${CMAKE_CURRENT_SOURCE_DIR}/src/vma_exporter.cpp"
    "${CMAKE_CURRENT_SOURCE_DIR}/include/vma_exporter.h"
)

# Include Vulkan headers.
target_include_directories(VmaExporter PUBLIC ${Vulkan_INCLUDE_DIRS})
target_include_directories(VmaExporter PRIVATE include)

# Link Vulkan library.
target_link_libraries(VmaExporter PRIVATE Vulkan::Vulkan)