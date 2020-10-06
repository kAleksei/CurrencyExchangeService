import React from "react"
// import { Container } from "reactstrap"
import NavMenu from "../components/NavMenu"
import { withStyles, Container } from "@material-ui/core";
import { compose } from "recompose"
import styles from './styles';

class Layout extends React.PureComponent {
  render() {
    return (
        <Container className={this.props.classes.layoutStyle} maxWidth={false}>

      {/* <React.Fragment className={this.props.classes.layoutStyle} color="primary"> */}
        <NavMenu />
            {this.props.children}
      {/* </React.Fragment> */}
        </Container>
    )
  }
}


export default compose(
  withStyles(styles)
)(Layout);
