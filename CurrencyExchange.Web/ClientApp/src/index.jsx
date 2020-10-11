/* eslint-disable no-undef */
import "bootstrap/dist/css/bootstrap.css"
import * as React from "react"
import * as ReactDOM from "react-dom"
import { Provider } from "react-redux"
import { ConnectedRouter } from "connected-react-router"
import { createBrowserHistory } from "history"
import configureStore from "./store/configureStore"
import App from "./App"
import registerServiceWorker from "./registerServiceWorker"
import { createMuiTheme, MuiThemeProvider } from "@material-ui/core"
import NanitoSans from "./fonts/NunitoSans-Regular.ttf"

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName("base")[0].getAttribute("href")
const history = createBrowserHistory({ basename: baseUrl })
const defaultTheme = createMuiTheme({
  palette: {
    primary: {
      main: "#E4EEFD",
    },
    secondary: {
      main: "#819EF9"
    }
  },
  overrides: {
    MuiCard: {
      root: {
        borderRadius: 15,
        boxShadow: "5px 5px 13px #b2bcca, -5px -5px 13px #ffffff",
        backgroundColor: "#E4EEFD",
        fontColor: "#212121",
      },
    },
    MuiTypography: {
      root: {
        fontFamily: "Segoe UI",
        color: "#212121",
      },
      h3: {
        fontFamily: "Segoe UI",
        fontSize: "2rem",
      },
      h4: {
        fontFamily: "Segoe UI",
        color: "#424242",
      },
      h6: {
        fontFamily: "Segoe UI",
        color: "#757575",
        fontSize: "small",
      }
    },
    MuiTabs: {
      indicator: {
        backgroundColor: "#819EF9",
        height: 3,
      }
    }
  },
})

// Get the application-wide store instance, prepopulating with state from the server where available.
const store = configureStore(history)

ReactDOM.render(
  <Provider store={store}>
    <MuiThemeProvider theme={defaultTheme}>
      <ConnectedRouter history={history}>
        <App />
      </ConnectedRouter>
    </MuiThemeProvider>
  </Provider>,
  document.getElementById("root")
)

registerServiceWorker()
