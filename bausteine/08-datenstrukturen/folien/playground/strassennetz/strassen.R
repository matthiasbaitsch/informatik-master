library(sf)
library(tidyverse)
library(tidygraph)
library(osmextract)
library(sfnetworks)
options(timeout = 3000)

net <- oe_get(
  "Germany",
  layer = "lines",
  extra_tags = c("ref"),
  query = "SELECT * FROM lines WHERE highway = 'motorway'",
  quiet = FALSE
) |>
  st_transform(25832) |>
  as_sfnetwork(directed = FALSE) |>
  activate("edges") |>
  mutate(laenge_km = as.numeric(st_length(geometry)) / 1000) |>
  convert(to_spatial_subdivision) |>
  convert(to_spatial_smooth)

edges_sf <- st_as_sf(net, "edges")
nodes_sf <- st_as_sf(net, "nodes")

# 2. Plot with ggplot layers
ggplot() +
  geom_sf(data = edges_sf, color = "gray50", size = 0.5) +
  geom_sf(data = nodes_sf, color = "red", size = 0.5) +
  theme_void()
