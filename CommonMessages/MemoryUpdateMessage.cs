﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMessages
{
    using EasyNetQ;

    /// <summary>   (Serializable) a memory update message. </summary>
    [Serializable]
    [Queue("Memory", ExchangeName = "EvolvedAI")]
    public class MemoryUpdateMessage
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier. </summary>
        ///
        /// <value> The identifier. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public long ID { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the text. </summary>
        ///
        /// <value> The text. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Text { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of generate 1 collections. </summary>
        ///
        /// <value> The number of generate 1 collections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Gen1CollectionCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of generate 2 collections. </summary>
        ///
        /// <value> The number of generate 2 collections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int Gen2CollectionCount { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the time spent percent. </summary>
        ///
        /// <value> The time spent percent. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public float TimeSpentPercent { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a collection of memory befores. </summary>
        ///
        /// <value> A Collection of memory befores. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MemoryBeforeCollection { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a collection of memory afters. </summary>
        ///
        /// <value> A Collection of memory afters. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MemoryAfterCollection { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the date. </summary>
        ///
        /// <value> The date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTime Date { get; set; }

    }
}
