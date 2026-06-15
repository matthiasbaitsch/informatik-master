library(sf)
library(tidyverse)
library(sfnetworks)

net <- as_sfnetwork(roxel) |>
  activate("edges") |>
  mutate(
    weight = as.numeric(edge_length())
  )

edges_sf <- st_as_sf(net, "edges")
nodes_sf <- st_as_sf(net, "nodes")

ggplot() +
  geom_sf(
    data = edges_sf,
    mapping = aes(color = weight),
    size = 0.5,
    show.legend = FALSE
  ) +
  geom_sf(data = nodes_sf, color = "red", size = 0.5) +
  theme_void()

ggsave("roxel.png", dpi = 600)
