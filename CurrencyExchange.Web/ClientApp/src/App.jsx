import * as React from "react"
import { Route, Switch } from "react-router"
import Layout from "./Layouts/Layout"
import mainRoutes from "./routes/mainRoutes"

export default () => (
  <Switch>
    <Layout>
      {mainRoutes.map((route) => {
        return <Route exact path={route.path} component={route.component} />
      })}
    </Layout>
  </Switch>
)
