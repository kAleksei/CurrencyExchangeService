import React from "react";
import HomeContainer from '../containers/Home/HomeContainer';
import Counter from '../containers/Counter';
import FetchData from '../containers/FetchData';
// const ProjectsContainer = React.lazy(() => import("../containers/Projects/ProjectsContainer"));

const mainRoutes = [
  {
    path: "/",
    component: HomeContainer,
  },
  {
    path: "/counter",
    component: Counter,
  },
  {
    path: "/fetch-data/:startDateIndex?",
    component: FetchData,
  },
];

export default mainRoutes;
