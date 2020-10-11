import React from "react"
import { compose } from "recompose"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { Row, Col } from "react-flexbox-grid"
import { withStyles, Paper, Tabs, Tab } from "@material-ui/core"
import styles from "./styles"
import CurrencyTrending from "../../Domains/enums/currencyTrending"
import classNames from "classnames"
import CurrencyCardComponent from "../../components/UI/CurrencyCard/CurrencyCardComponent"
// import Paper from '@material-ui/core/Paper';
// import Tabs from '@material-ui/core/Tabs';
// import Tab from '@material-ui/core/Tab';

class HomeContainer extends React.PureComponent {

  cities = [
    {id: 0, name: 'Lviv'},
    {id: 1, name: 'Kyiv'},
  ]

  cards = [
    {
      id: "1",
      name: "EUR",
      rate: 26.55,
      currencyTrending: CurrencyTrending.up,
      lastUpdate: new Date().toDateString,
    }
  ]



  render() {
    const { classes } = this.props
    return (
      <>
      <Row>
        <Col md={12} colors="primary">
        <Paper className={classes.citiesTabWrapper}>
          <Tabs
            value={0}
            indicatorColor="primary"
            textColor="primary"
            // onChange={handleChange}
            aria-label="Cities"
            // TabIndicatorProps={
              // <div style={{ backgroundColor: "red"}}></div>
              // }
          >
            {this.cities.map(city =>(
              <Tab label={city.name} className={classes.cityTab} />
            ))}

          </Tabs>
        </Paper>
        <Row>
          {this.cards.map((card) => (
            <CurrencyCardComponent card={card} />
          ))}
        </Row>
        </Col>  
      </Row>
      </>
    )
  }
}

const mapStateToProps = (state) => {
  //   const { user } = state.auth;
  //   const { canSendSatisfactionFeedback } = state.employeeFeedback;
  //   return {
  //     user,
  //     canSendSatisfactionFeedback,
  //   };
}

const mapDispatchToProps = (dispatch) => bindActionCreators({}, dispatch)

export default compose(
  connect(mapStateToProps, mapDispatchToProps),
  withStyles(styles)
)(HomeContainer)
