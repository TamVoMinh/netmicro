import React from 'react';
function Page({ component: Component, layout: LayoutComponent, data }) {
    return LayoutComponent ? (
        <LayoutComponent>
            <Component {...data} />
        </LayoutComponent>
    ) : (
        <Component {...data} />
    );
}

export default Page;
