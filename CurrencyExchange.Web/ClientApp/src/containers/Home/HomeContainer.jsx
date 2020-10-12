import React from "react"
import { compose } from "recompose"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { Row, Col } from "react-flexbox-grid"
import { withStyles, Paper, Tabs, Tab } from "@material-ui/core"
import styles from "./styles"
// import CurrencyTrending from "../../Domains/enums/currencyTrending"
// import classNames from "classnames"
import CurrencyCardComponent from "../../components/UI/CurrencyCard/CurrencyCardComponent"
import {fetchCities} from "../../actions/cityActions"
import {fetchCurrencies} from "../../actions/currencyActions"


class HomeContainer extends React.PureComponent {
  constructor(props) {
    super(props);
    this.state = {
      selectedCityId: null
    }
  }

  componentDidMount(){
    this.props.fetchCities().then(cities => this.setState({ selectedCityId: cities[0].id, withHistory: true}))
  }

  componentDidUpdate(prevProps, prevState) {
    if(prevState.selectedCityId !== this.state.selectedCityId){
      this.props.fetchCurrencies({cityId: this.state.selectedCityId, withHistory: true});
    }
  }

  setCurrentCity = (event, newValue) => {
    this.setState({selectedCityId: newValue})
  }


  render() {
    const { classes, cities, currencies } = this.props
    return (
      <>
      <Row>
        <Col md={12} colors="primary">
        <Paper className={classes.citiesTabWrapper}>
          <Tabs
            value={this.state.selectedCityId}
            indicatorColor="primary"
            textColor="primary"
            onChange={this.setCurrentCity}
            aria-label="Cities"
            variant="scrollable"
            scrollButtons="on"
          >
            {cities.map(city =>(
              <Tab label={city.name} className={classes.cityTab} value={city.id} disableFocusRipple disableRipple />
            ))}

          </Tabs>
        </Paper>
        <Row>
          {currencies.map((card) => (
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
    const { cities } = state.city;
    const { currencies } = state.currency;
    return {
      cities,
      currencies,
    };
}

const mapDispatchToProps = (dispatch) => bindActionCreators({
  fetchCurrencies,
  fetchCities
}, dispatch)

export default compose(
  connect(mapStateToProps, mapDispatchToProps),
  withStyles(styles)
)(HomeContainer)
