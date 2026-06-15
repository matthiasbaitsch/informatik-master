library(sf)
library(sfnetworks)
library(osmextract)
library(tidygraph)
library(tidyverse)
options(timeout = 3000)

de <- oe_get(
  "Germany",
  layer = "lines",
  extra_tags = c("ref"),
  query = "SELECT * FROM lines WHERE highway = 'motorway'",
  
  quiet = FALSE
)

de <- st_transform(de, 25832)

net <- as_sfnetwork(de, directed = FALSE) %>%
  activate("edges") %>%
  mutate(laenge_km = as.numeric(st_length(geometry)) / 1000) %>%
  convert(to_spatial_subdivision)  %>%
   convert(to_spatial_smooth)

# net_de |>
#   select(from, to, laenge_km) |>
#   plot()

# ggplot(data = de) +
#   geom_sf()

edges_sf <- st_as_sf(net, "edges")
nodes_sf <- st_as_sf(net, "nodes")

# 2. Plot with ggplot layers
ggplot() +
  geom_sf(data = edges_sf, color = "gray50", size = 0.5) +
  geom_sf(data = nodes_sf, color = "red", size = 0.5) +
  theme_void()
