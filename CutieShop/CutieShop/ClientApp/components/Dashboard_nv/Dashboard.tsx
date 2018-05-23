import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import { WarningBanner } from './WarningBanner';
import { ContentDashboard } from './ContentDashboard';

export class Dashboard extends React.Component<{ IsAllowAccess: boolean }, { showWarning: boolean }>{

    constructor(props) {
        super(props);
    }

    IsWarn = false;
    IsShow = true;


    componentWillReceiveProps() {
        if (this.props.IsAllowAccess == true) {
            this.IsWarn = !this.IsWarn;
            this.IsShow = !this.IsShow;
        }
        else {
            this.IsWarn = !this.IsWarn;
            this.IsShow = !this.IsShow;
        }
    }

    render() {
        return (
            <div>
                <WarningBanner warn={this.IsWarn} />
                <ContentDashboard Show={this.IsShow} />
            </div>
        );
    }
}