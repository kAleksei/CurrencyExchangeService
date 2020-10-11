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
        <NavMenu />
            {this.props.children}
        </Container>
    )
  }
}

export default compose(
  withStyles(styles)
)(Layout);
