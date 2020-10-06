import * as React from 'react';
import { Route, Switch } from 'react-router';
import Layout from './Layouts/Layout';
import Counter from './containers/Counter';
import FetchData from './containers/FetchData';
import mainRoutes from "./routes/mainRoutes";

import './custom.css'

export default () => (
  <Switch>
    <Layout>
    {mainRoutes.map((route) => {
          return <Route exact path={route.path} component={route.component} />;
        })}
        {/* <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data/:startDateIndex?' component={FetchData} /> */}
    </Layout>
  </Switch>
);
