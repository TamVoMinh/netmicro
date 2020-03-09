import React from "react";

function ErrorIconSVG({ color = "#FFFFFF", ...other }) {
    return <svg width="20px" height="19px" viewBox="0 0 20 19" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlnsXlink="http://www.w3.org/1999/xlink">
        <title>Error</title>
        <desc>Created with Sketch.</desc>
        <g id="Styleguide" stroke="none" strokeWidth="1" fill="none" fillRule="evenodd">
            <g id="GridUI-Style-Guide" transform="translate(-170.000000, -5096.000000)" fill={color} fillRule="nonzero">
                <path d="M180,5096.25781 C180.782157,5096.25781 181.509842,5096.64955 181.963872,5097.31178 L182.063691,5097.46935 L189.665655,5110.53666 C190.107874,5111.29387 190.107874,5112.22416 189.686713,5113.003 C189.273975,5113.72993 188.567734,5114.193 187.773442,5114.25152 L187.601964,5114.25781 L172.398036,5114.25781 C171.513597,5114.25781 170.734448,5113.78185 170.313287,5113.003 C169.922208,5112.27979 169.894274,5111.426 170.246345,5110.70145 L170.334345,5110.53666 L177.936309,5097.44772 C178.378528,5096.71214 179.157677,5096.25781 180,5096.25781 Z M179.966822,5109.05781 C179.191285,5109.05781 178.684525,5109.60777 178.700361,5110.34166 C178.684525,5111.04173 179.191285,5111.60883 179.951426,5111.60883 C180.743239,5111.60883 181.24956,5111.04173 181.25,5110.34166 C181.233724,5109.60823 180.7428,5109.05781 179.966822,5109.05781 Z M179.95,5101.25781 C179.259583,5101.25781 178.7,5101.76537 178.7,5102.3916 L178.881156,5104.6328 C178.953618,5105.57103 178.998907,5106.2357 179.017023,5106.62682 L179.02608,5106.92675 C179.02608,5107.55298 179.259583,5107.94079 179.95,5107.94079 C180.594389,5107.94079 180.840224,5107.60296 180.870138,5107.04877 L180.873309,5106.92675 L181.2,5102.3916 C181.2,5101.76537 180.640417,5101.25781 179.95,5101.25781 Z" id="Error"></path>
            </g>
        </g>
    </svg>
}

export default React.memo(ErrorIconSVG);