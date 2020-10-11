import React from "react"
import { compose } from "recompose"
import { connect } from "react-redux"
import { bindActionCreators } from "redux"
import { Row, Col } from "react-flexbox-grid"
import { withStyles, Card, Typography } from "@material-ui/core"
import styles from "./styles"
import TrendingDownIcon from "@material-ui/icons/TrendingDown"
import TrendingFlatIcon from "@material-ui/icons/TrendingFlat"
import TrendingUpIcon from "@material-ui/icons/TrendingUp"
import CurrencyTrending from "../../../Domains/enums/currencyTrending"
import classNames from "classnames"

class CurrencyCardComponent extends React.PureComponent {
  getClassNameByCurrency(currencyTrending) {
    switch (currencyTrending) {
      case CurrencyTrending.notChanged:
        return "trendIconNotChanged"
      case CurrencyTrending.up:
        return "trendIconUp"
      case CurrencyTrending.down:
        return "trendIconDown"
      default:
        return "trendIconNotChanged"
    }
  }

  render() {
    const { classes, card } = this.props
    return (
      <Col md={3}>
        <Card className={classes.currencyCard}>
          <Row style={{ position: "relative" }}>
            <Typography variant="h4" className={classes.currencyCode}>{card.code}</Typography>
            <Typography variant="h6" className={classes.currencyToUsdTitle}>
              /USD
            </Typography>
          </Row>
          <Row>
            <Typography variant="h3" className={classes.rateText}>
              {card.rate}
            </Typography>
            <React.Fragment className={classes.trendIconWrapper}>
              {card.currencyTrending === CurrencyTrending.down ? (
                <TrendingDownIcon
                  className={classNames(
                    classes.trendIcon,
                    classes[this.getClassNameByCurrency(card.currencyTrending)]
                  )}
                />
              ) : card.currencyTrending === CurrencyTrending.up ? (
                <TrendingUpIcon
                  className={classNames(
                    classes.trendIcon,
                    classes[this.getClassNameByCurrency(card.currencyTrending)]
                  )}
                />
              ) : (
                <TrendingFlatIcon
                  className={classNames(
                    classes.trendIcon,
                    classes[this.getClassNameByCurrency(card.currencyTrending)]
                  )}
                />
              )}
            </React.Fragment>
          </Row>
          <Typography variant="h6">Last update: {card.lastUpdate}</Typography>
        </Card>
      </Col>
    )
  }
}

export default compose(
    withStyles(styles)
  )(CurrencyCardComponent)
