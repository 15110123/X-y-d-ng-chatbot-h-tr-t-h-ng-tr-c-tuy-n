import * as React from 'react'
import { RouteComponentProps, Redirect, Route } from 'react-router'
import { Props } from 'react';
import { WarningBanner } from './WarningBanner';

export class Dashboard extends React.Component<{ IsAllowAccess: boolean }, { showWarning: boolean }>{

    constructor(props) {
        super(props);
    }

    IsWarn = false;

    componentWillReceiveProps() {
        this.IsWarn = !this.IsWarn;
    }

    render() {
        return (
            <div>
                <WarningBanner warn={this.IsWarn} />
            </div>
        );
    }
}